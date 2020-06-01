import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(public auth: AuthService) { }

  currentUser: string;
  userID: string;
  ID: number;

  ngOnInit() {
  }

  getSessionScope() {
    this.auth.userProfile$.subscribe(data => this.currentUser = data);
    console.log(this.currentUser);
    console.log("This is the auth0 ID: ", this.currentUser.sub);
    this.userID = this.currentUser.sub.toString();
    console.log("substring: ", this.userID);
    this.ID = <number> + this.userID.substr(6);
    console.log("this is the ID number: ", this.ID);
  }

}
