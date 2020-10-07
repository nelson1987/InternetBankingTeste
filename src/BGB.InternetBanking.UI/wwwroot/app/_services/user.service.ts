import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';

import { AppConfig } from '../app.config';
import { User } from '../_models/index';

@Injectable()
export class UserService {
    constructor(private http: Http, private config: AppConfig) { }

    getAll() {
        return this.http.get(this.config.apiUrl + '/api/v1.0/user/getall', this.jwt()).map((response: Response) => response.json());
    }

    getById(id: number) {
        return this.http.get(this.config.apiUrl + '/api/v1.0/user?id=' + id, this.jwt()).map((response: Response) => response.json());
    }

    getByAccount(accountNumber: number) {
        return this.http.get(this.config.apiUrl + '/api/v1.0/user/GetByAccount?accountNumber=' + accountNumber, this.jwt()).map((response: Response) => response.json());
    }

    create(user: User) {
        return this.http.post(this.config.apiUrl + '/api/v1.0/user', user, this.jwt());
    }

    //update(user: User) {
    //    return this.http.put(this.config.apiUrl + '/api/v1.0/user/' + user.id, user, this.jwt());
    //}

    //delete(id: number) {
    //    return this.http.delete(this.config.apiUrl + '/api/v1.0/user/' + id, this.jwt());
    //}

    // private helper methods

    private jwt() {
        // create authorization header with jwt token
        let currentUser = JSON.parse(localStorage.getItem('currentUser'));
        if (currentUser != null && currentUser.Token != null) {
            let headers = new Headers({ 'Authorization': 'Bearer ' + currentUser.Token });
            return new RequestOptions({ headers: headers });
        }
    }
}