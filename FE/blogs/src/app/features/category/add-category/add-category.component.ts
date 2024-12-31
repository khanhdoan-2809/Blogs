import { Component, OnDestroy } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AddCategoryRequest } from '../models/add-category-request.model';
import { CategoryService } from '../services/category.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-add-category',
  standalone: true,
  imports: [RouterModule, FormsModule],
  templateUrl: './add-category.component.html',
  styleUrl: './add-category.component.css'
})
export class AddCategoryComponent implements OnDestroy {

  model: AddCategoryRequest;
  private addCategorySubcription?: Subscription
  
  constructor(private categoryService: CategoryService) {
    this.model = {
      name: '',
      urlHandle: ''
    }
  }

  onFormSubmit() {
    this.addCategorySubcription = this.categoryService.addCategory(this.model).subscribe({
      next: (response) => {
        console.log(response)
      },
      error: () => {

      }
    })
  }

  ngOnDestroy(): void {
      this.addCategorySubcription?.unsubscribe()
  }
}
