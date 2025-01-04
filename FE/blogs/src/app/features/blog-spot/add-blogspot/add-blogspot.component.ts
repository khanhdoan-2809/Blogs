import { Component } from '@angular/core';
import { AddBlogPost } from '../models/add-blog-post.model';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BlogPostService } from '../services/blog-post.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-blogspot',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './add-blogspot.component.html',
  styleUrl: './add-blogspot.component.css'
})
export class AddBlogspotComponent {
  model: AddBlogPost

  constructor(private blogPostService: BlogPostService, private router: Router) {
    this.model = {
      title: '',
      shortDescription: '',
      urlHandle: '',
      content: '',
      featuredImageUrl: '',
      author: '',
      isVisible: true,
      publishDate: new Date()
    }
  }

  onSubmit(): void {
    this.blogPostService.createBlogPost(this.model)
    .subscribe({
      next: (response) => {
        this.router.navigateByUrl('/admin/blogposts')
      }
    })
  }
}
