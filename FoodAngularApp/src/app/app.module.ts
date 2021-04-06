import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from "@angular/forms"

import { AppComponent } from './app.component';
import { FoodsComponent } from './foods/foods.component';
import { FoodComponent } from './foods/food/food.component';
import { FoodListComponent } from './foods/food-list/food-list.component';
import { FoodService } from './shared/food.service';

@NgModule({
  declarations: [
    AppComponent,
    FoodsComponent,
    FoodComponent,
    FoodListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [FoodService],
  bootstrap: [AppComponent]
})
export class AppModule { }
