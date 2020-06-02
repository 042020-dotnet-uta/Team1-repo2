import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  constructor(public auth: AuthService) { 
    this.auth.userProfile$.subscribe(data => {
      this.currentUser = data;
      this.username = this.currentUser.nickname;
      console.log(this.username);
      console.log(this.currentUser);
      console.log(this.currentUser.nickname);
      console.log('constructor is running');
    });
  }
  public currentUser;
  public username: string;

  ngOnInit(): void {
    /*this.auth.userProfile$.subscribe(data => this.currentUser = data);
    console.log(this.currentUser);
    this.username = this.currentUser[0];
    console.log(this.username);*/
  }

}
