import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;

  profileImage: string;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  constructor(public auth: AuthService) { }

  getProfileImage(): string {
    this.auth.userProfile$.subscribe(data => {
      this.profileImage = data.picture;
    });
    return this.profileImage;
  }

  ngOnInit() {
  }
}
