import { mapToMapExpression } from '@angular/compiler/src/render3/util';
import { Injectable } from '@angular/core';
import { Food } from './food.model';

@Injectable({
  providedIn: 'root'
})
export class FoodService {

  formData : Food;


  constructor() { }

  postFood(formData : Food) {
    return true;
  }


}
