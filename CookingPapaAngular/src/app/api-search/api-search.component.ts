import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-api-search',
  templateUrl: './api-search.component.html',
  styleUrls: ['./api-search.component.css']
})
export class ApiSearchComponent implements OnInit {

  constructor(private http: HttpClient) { }

  recipeData: any;
  
  getData(query) {
    fetch("https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/search?number=5&offset=20&query=" + query, {
    "method": "GET",
    "headers": {
      "x-rapidapi-host": "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com",
      "x-rapidapi-key": "2c8fa441c2mshb2f3311803acdfap1adb69jsn81bb9d6644d3"
    }
    })
    .then(response => response.json())
      /*console.log(response.json());
      console.log(response);
      response.json().then(data => console.log(data));
      /*this.data = response.json();

      console.log("these are the results: ", this.data);
      console.log("more data: ", this.data.Value);
      console.log("more data: ", this.data.Value.number);/*
      console.log("object: ", this.data.object.number);
      console.log("object without object keyword: ", this.data.number);
      console.log("second index: ", this.data.results[1]);*/
      //console.log("the parse: ", JSON.parse(this.data));
    .then(data => {
      console.log('Success: ', data);
      console.log(data.results);
      console.log(data.results[1]);
      this.recipeData = data.results;
    })
    .catch(err => {
      console.log(err);
    });
  }

  didFetchWork() {
    console.log(this.recipeData);
    console.log("button works");
  }

  testing() {
    this.recipeData = [
      {
        id: 262682, 
        title: "Thai Sweet Potato Veggie Burgers with Spicy Peanut Sauce", 
        readyInMinutes: 75,
        image: "thai-sweet-potato-veggie-burgers-with-spicy-peanut-sauce-262682.png",
        sourceUrl: "http://www.food.com/recipe/"
      },
      {
        id: 602708,
        title: "Meatless Monday: Grilled Portobello Mushroom Burgers with Romesco and Arugula",
        readyInMinutes:15,
        image:"Meatless-Monday--Grilled-Portobello-Mushroom-Burgers-with-Romesco-and-Arugula-602708.jpg",
        sourceUrl: "http://www.food.com/recipe/"
      },
      {
        id: 262682, 
        title: "Thai Sweet Potato Veggie Burgers with Spicy Peanut Sauce", 
        readyInMinutes: 75,
        image: "thai-sweet-potato-veggie-burgers-with-spicy-peanut-sauce-262682.jpg",
        sourceUrl: "http://www.food.com/recipe/"},
      {
        id: 602708,
        title: "Meatless Monday: Grilled Portobello Mushroom Burgers with Romesco and Arugula",
        readyInMinutes:15,
        image:"Meatless-Monday--Grilled-Portobello-Mushroom-Burgers-with-Romesco-and-Arugula-602708.jpg",
        sourceUrl: "http://www.food.com/recipe/"
      }
    ];
    console.log(this.recipeData);
  }

  ngOnInit(): void {
  }

}