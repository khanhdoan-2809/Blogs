import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { CategoryService } from '../services/category.service';
import { Category } from '../models/category.mode';
import { FormsModule } from '@angular/forms';
import { UpdateCateroryRequest } from '../models/update-category-request-model';

@Component({
  selector: 'app-edit-category',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './edit-category.component.html',
  styleUrl: './edit-category.component.css'
})
export class EditCategoryComponent implements OnInit, OnDestroy {
  id: string | null = null;
  paramsSubcription?: Subscription
  editCategorySubcription?: Subscription
  category: Category

  constructor(private route: ActivatedRoute, private categoryService: CategoryService, private router: Router) {

  }

  ngOnInit(): void {
      this.paramsSubcription = this.route.paramMap.subscribe({
        next: (params) => {
          this.id = params.get('id')
          if (this.id) {
            this.categoryService.getCategoryById(this.id)
            .subscribe({
              next: (response) => {
                this.category = response
              }
            })
          }
        }
      });
  }

  onFormSubmit(): void {
    const updateCateroryRequest: UpdateCateroryRequest = {
      name: this.category?.name ?? '',
      urlHandle: this.category?.urlHandle ?? ''
    }

    if (this.id) {
      this.editCategorySubcription = this.categoryService.updateCategory(this.id, updateCateroryRequest)
      .subscribe({
        next: (response) => {
          this.router.navigateByUrl('/admin/categories')
        }
      })
    }
  }

  onDelete(): void {
    if (this.id) {
      this.categoryService.deleteCategory(this.id)
      .subscribe({
        next: (response) => {
          this.router.navigateByUrl('/admin/categories')
        }
      })
    }
  }

  ngOnDestroy(): void {
      this.paramsSubcription?.unsubscribe()
      this.editCategorySubcription?.unsubscribe()
  }
}
