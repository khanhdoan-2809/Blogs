import { Routes } from '@angular/router';
import { CategoryListComponent } from './features/category/category-list/category-list.component';
import { AddCategoryComponent } from './features/category/add-category/add-category.component';
import { EditCategoryComponent } from './features/category/edit-category/edit-category.component';
import { BlogspotListComponent } from './features/blog-spot/blogspot-list/blogspot-list.component';
import { AddBlogspotComponent } from './features/blog-spot/add-blogspot/add-blogspot.component';

export const routes: Routes = [
    {
        path: 'admin/categories',
        component: CategoryListComponent
    },
    {
        path: 'admin/categories/add',
        component: AddCategoryComponent
    },
    {
        path: 'admin/categories/:id',
        component: EditCategoryComponent
    },
    {
        path: 'admin/blogspots',
        component: BlogspotListComponent
    },
    {
        path: 'admin/blogspots/add',
        component: AddBlogspotComponent
    }
];
