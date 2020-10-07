import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { User } from '../_models/index';
import { AlertService, AuthenticationService } from '../_services/index';

@Component({
    moduleId: module.id,
    templateUrl: 'selectuser.component.html',
    styleUrls: ['selectuser.css']
})

export class SelectUserComponent implements OnInit {
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

    getaccounts() {
        this.loading = true;
        this.authenticationService.GetAccounts(this.model.accountnumber)
            .subscribe(
            data => {
                this.users = JSON.parse(data);
                //this.router.navigate([this.returnUrl]);
            },
            error => {
                var message = JSON.parse(error._body);
                //this.alertService.error('loinggg or password is incorrect');
                this.alertService.error(message.Message);

                this.loading = false;
            });

        var t = this.users;

        var e = t;
    }
}
