﻿// Copyright (c) János Janka. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

import { http, HttpAsyncResult } from "../core";

/** Used to log in a user to the system. **/
export interface LoginOptions {
    email: string;
    password: string;
}

/** Used to register a new user to the system. */
export interface RegisterOptions {
    email: string;
    password: string;
    firstName?: string;
    lastName?: string;
    gender?: "male" | "female";
    birthday?: Date;
}

/** This class is the entry point for Account Management. */
export class AccountService {

    /** A static instance of the service. This field is read-only. */
    static readonly default: AccountService = new AccountService();

    /** Logs in using an authentication provider as a HTTP POST operation. */
    login(options: LoginOptions): HttpAsyncResult<void> {
        return http<void>({
            path: "account/login",
            method: "post",
            params: options
        });
    }

    /** Registers a new account as a HTTP POST operation. */
    register(options: RegisterOptions): HttpAsyncResult<void> {
        return http<void>({
            path: "account/register",
            method: "post",
            params: options
        });
    }

    /** Unregisters an existing account as a HTTP POST operation. */
    unregister(options: LoginOptions): HttpAsyncResult<void> {
        return http<void>({
            path: "account/unregister",
            method: "post",
            params: options
        });
    }

}