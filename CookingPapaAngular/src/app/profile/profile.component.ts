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
  userID: number;
  username: string;
  profileImage: string;
  email: string;

  ngOnInit() {
    this.auth.userProfile$.subscribe(data => {
      this.userID = <number> + data.sub.toString().substr(6);
      this.username = data.name;
      this.profileImage = data.picture;
      this.email = data.email;
    })
  }
}
