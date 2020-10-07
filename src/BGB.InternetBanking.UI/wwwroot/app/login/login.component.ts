import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { AlertService, AuthenticationService } from '../_services/index';

import { User } from '../_models/index';

@Component({
    moduleId: module.id,
    templateUrl: 'login.component.html',
    styleUrls: [ 'login.css' ]
})

export class LoginComponent implements OnInit {
    model: any = {};
    loading = false;
    returnUrl: string;
    users: User[] = [];

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService,
        private alertService: AlertService) { }

    ngOnInit() {
        // reset login status
        this.authenticationService.logout();

        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    login() {
        //this.loading = true;
        //this.authenticationService.login(this.model.accountnumber, this.model.login, this.model.key)
        //    .subscribe(
        //    data => {
        //        this.router.navigate([this.returnUrl]);
        //    },
        //    error => {
        //        var message = JSON.parse(error._body);
        //        //this.alertService.error('loinggg or password is incorrect');
        //        this.alertService.error(message.Message);

        //        this.loading = false;
        //    });
        this.loading = true;

        var t = this.authenticationService.GetAccountsTest(this.model.accountnumber);

        var e = t;

        //this.authenticationService.GetAccounts(this.model.accountnumber)
        //    .subscribe(
        //    data => {
        //        this.users = JSON.parse(data);
        //        var t = '';
        //    },
        //    error => {
        //        var message = JSON.parse(error._body);
        //        //this.alertService.error('loinggg or password is incorrect');
        //        this.alertService.error(message.Message);

        //        this.loading = false;
        //    });
    }
}
