﻿/**
  * @license
  * Copyright (c) János Janka. All rights reserved.
  * Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
  */

import * as ko from "knockout";

function asNumber(n: any) {
    return n === undefined ? 0 : +n;
}

/** Defines a set of key/value pairs to configure a Time Span control. */
interface TimeSpanParams {
    value: KnockoutObservable<string>;
}

class TimeSpan {
    private _disposed: boolean;
    private _listening: boolean;

    private _d: KnockoutSubscription;
    private _h: KnockoutSubscription;
    private _m: KnockoutSubscription;
    private _s: KnockoutSubscription;

    days: KnockoutObservable<number>;
    hours: KnockoutObservable<number>;
    minutes: KnockoutObservable<number>;
    seconds: KnockoutObservable<number>;
    value: KnockoutObservable<string>;

    /**
     * Initializes a new instance of the TimeSpan class.
     * @param params A set of key/value pairs to configure the TimeSpan control.
     */
    constructor(params: TimeSpanParams) {
        this._disposed = false;
        this._listening = true;

        this.days = ko.observable<number>().extend({ displayName: "controls:timespan.days" });
        this.hours = ko.observable<number>().extend({ displayName: "controls:timespan.hours" });
        this.minutes = ko.observable<number>().extend({ displayName: "controls:timespan.minutes" });
        this.seconds = ko.observable<number>().extend({ displayName: "controls:timespan.seconds" });

        this.value = params.value;

        this.loadFromString(ko.unwrap(this.value));

        this._d = this.days.subscribe(this.timeChanged, this);
        this._h = this.hours.subscribe(this.timeChanged, this);
        this._m = this.minutes.subscribe(this.timeChanged, this);
        this._s = this.seconds.subscribe(this.timeChanged, this);
    }

    /** Raised immediately after one of the time values has changed. */
    timeChanged(): void {
        if (!this._listening) {
            return;
        }
        this._listening = false;
        var time = this.toObject();
        var rem = time.seconds % 60;
        time.minutes += (time.seconds - rem) / 60;
        time.seconds = rem;
        rem = time.minutes % 60;
        time.hours += (time.minutes - rem) / 60;
        time.minutes = rem;
        rem = time.hours % 24;
        time.days += (time.hours - rem) / 24;
        time.hours = rem;
        this.setValues(time.days, time.hours, time.minutes, time.seconds);
        this.value(this.toString());
        this._listening = true;
    }

    /**
     * Loads time values from the specified string.
     * @param value A string that contains time values.
     */
    loadFromString(value: string): void {
        const slots = value ? value.split(":", 4) : [];
        this.setValues(asNumber(slots[0]), asNumber(slots[1]), asNumber(slots[2]), asNumber(slots[3]));
    }

    /**
     * Updates all the time components using the specified values.
     * @param days     The days component of the time interval.
     * @param hours    The hours component of the time interval.
     * @param minutes  The minutes component of the time interval.
     * @param seconds  The seconds component of the time interval.
     */
    setValues(days: number, hours: number, minutes: number, seconds: number): void {
        this.days(days);
        this.hours(hours);
        this.minutes(minutes);
        this.seconds(seconds);
    }

    /** Converts this time span to native JS object. */
    toObject(): { days: number, hours: number, minutes: number, seconds: number } {
        return {
            days: this.days(),
            hours: this.hours(),
            minutes: this.minutes(),
            seconds: this.seconds()
        };
    }

    /** Converts this time span to string. */
    toString(): string {
        const time = this.toObject();
        return `${time.days}:${time.hours}:${time.minutes}:${time.seconds}`;
    }

    /** Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources. */
    dispose(): void {
        if (this._disposed) {
            return;
        }
        this._d && this._d.dispose(), this._d = null;
        this._h && this._h.dispose(), this._h = null;
        this._m && this._m.dispose(), this._m = null;
        this._s && this._s.dispose(), this._s = null;
        this._disposed = true;
    }
}

export default {
    viewModel: TimeSpan,
    template: require("./knockout-timespan.html")
};