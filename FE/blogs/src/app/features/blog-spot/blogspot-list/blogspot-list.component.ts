import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BlogPostService } from '../services/blog-post.service';
import { Observable } from 'rxjs';
import { BlogPost } from '../models/blog-post.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-blogspot-list',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './blogspot-list.component.html',
  styleUrl: './blogspot-list.component.css'
})
export class BlogspotListComponent implements OnInit {

  blogPosts$?: Observable<BlogPost[]>;
  constructor(private blogPostService: BlogPostService) {

  }

  ngOnInit(): void {
      this.blogPosts$ = this.blogPostService.getAllBlogPosts();
  }

}
