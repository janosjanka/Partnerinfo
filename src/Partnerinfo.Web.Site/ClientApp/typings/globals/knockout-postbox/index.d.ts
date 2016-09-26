// Generated by typings
// Source: https://raw.githubusercontent.com/DefinitelyTyped/DefinitelyTyped/55c3e254e151847b8d37ca09b1a566ad4a48a66a/knockout.postbox/knockout-postbox.d.ts
interface KnockoutPostBox {
    subscribe<T>(topic: string, handler: (value: T) => void , target?: any): KnockoutSubscription;
    publish<T>(topic: string, value?: T): void;
    defaultComparer<T>(newValue: T, oldValue: T): boolean;
    serializer: (object: any) => string;
    reset(): void;
}

interface KnockoutObservable<T> {
    subscribeTo(topic: string, useLastPublishedValueToInitialize?: boolean, transform?: (val: any) => T): KnockoutObservable<T>;
    unsubscribeFrom(topic: string): KnockoutObservable<T>;
    publishOn(topic: string, skipInitialPublish?: boolean, equalityComparer?: (newValue: T, oldValue: T) => boolean): KnockoutObservable<T>;
    stopPublishingOn(topic: string): KnockoutObservable<T>;
    syncWith(topic: string, initializeWithLatestValue?: boolean, skipInitialPublish?: boolean, equalityComparer?: (newValue: T, oldValue: T) => boolean): KnockoutObservable<T>;
}

interface KnockoutObservableArray<T> {
	subscribeTo(topic: string, useLastPublishedValueToInitialize?: boolean, transform?: (val: any) => any /* T */): KnockoutObservableArray<T>;
	unsubscribeFrom(topic: string): KnockoutObservableArray<T>;
	publishOn(topic: string, skipInitialPublish?: boolean, equalityComparer?: (newValue: any /* T */, oldValue: any /* T */) => boolean): KnockoutObservableArray<T>;
	stopPublishingOn(topic: string): KnockoutObservableArray<T>;
	syncWith(topic: string, initializeWithLatestValue?: boolean, skipInitialPublish?: boolean, equalityComparer?: (newValue: any /* T */, oldValue: any /* T */) => boolean): KnockoutObservableArray<T>;
}

interface KnockoutStatic {
    postbox: KnockoutPostBox;
}