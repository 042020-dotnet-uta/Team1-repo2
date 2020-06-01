import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RecipeSearchService {
     recipes : string[] = [
      'Good Food',
      'Gross Food',
      'Some Food',
      'Some More Food',
      'Eat it Damnit',
      'Sure why not'
    ];
  constructor(private http: HttpClient) { }

  getRecipes(searchTerm: string) {
    return this.recipes;
    // return this.http.get<YesNoResponse>(environment.yesNoUrl).toPromise()
    //   .then(yesNo => yesNo.answer);
  }
}
