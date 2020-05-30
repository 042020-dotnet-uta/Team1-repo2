import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'app-view-cookbook',
  templateUrl: './view-cookbook.component.html',
  styleUrls: ['./view-cookbook.component.css']
})
export class ViewCookbookComponent implements OnInit {

  constructor(private location:Location) { }

  goBack():void{
    this.location.back();
  }
  ngOnInit(): void {
  }

}
