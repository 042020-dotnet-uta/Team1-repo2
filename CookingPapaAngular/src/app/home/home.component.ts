import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  constructor(public auth: AuthService) { 
  }

  public username: string;

  getUsername(): string {
    this.auth.userProfile$.subscribe(data => {
      this.username = data.name;
    });
    return this.username;
  }

  ngOnInit(): void {
  }

}
