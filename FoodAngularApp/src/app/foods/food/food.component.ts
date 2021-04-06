import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FoodService } from 'src/app/shared/food.service';

@Component({
  selector: 'app-food',
  templateUrl: './food.component.html',
  styleUrls: ['./food.component.css']
})
export class FoodComponent implements OnInit {

  constructor(public service : FoodService) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form!=null)
    form.resetForm();
    this.service.formData = {
      FoodID : null,
      FoodName : '',
      FoodURL : ''
    }
  }

  onSubmit(form: NgForm) {
    this.insertRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postFood(form.value).subscribe(res => {
      this.resetForm(form)
    })
  }

}

