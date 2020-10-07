import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'

import { AppConfig } from '../app.config';

import { User } from '../_models/index';

@Injectable()
export class AuthenticationService {
    constructor(private http: Http, private config: AppConfig) { }

    login(accountnumber: string, login: string, key: string) {

        var model = {
            AccountNumber: accountnumber,
            Login: login,
            Key: key,
            TemporaryKey: false
        };

       return this.http.post(this.config.apiUrl + '/api/v1.0/security/authenticate', model)
            .map((response: Response) => {
                // login successful if there's a jwt token in the response
                let credential = response.json();
                //if (credential && credential.Token) {
                if (response.status == 200) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    //localStorage.setItem('currentUser', JSON.stringify(credential));
                    sessionStorage.setItem('currentUser', JSON.stringify(credential));
                }
            });
    }

    GetAccounts(accountnumber: string) {

            //return this.http.get(this.config.apiUrl + '/api/v1.0/user/GetByAccount?accountNumber=' + accountNumber, this.jwt()).map((response: Response) => response.json());
        var tt = this.http.get(this.config.apiUrl + '/api/v1.0/user/GetByAccount?accountNumber=' + accountnumber + '&accountDigit=0').map((response: Response) => response.json());

        return tt;
    }


    GetAccountsTest(accountnumber: string) {

        var tt = this.http.get(this.config.apiUrl + '/api/v1.0/user/GetByAccount?accountNumber=' + accountnumber + '&accountDigit=0');

        return tt;
    }

    logout() {
        // remove user from local storage to log user out
        //localStorage.removeItem('currentUser');
        sessionStorage.removeItem('currentUser');
    }

}