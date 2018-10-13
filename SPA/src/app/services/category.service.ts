import { Category } from './../interfaces/category';
import { Injectable, isDevMode } from '@angular/core';
import { HttpClient } from '../../../node_modules/@angular/common/http';
import { Observable } from '../../../node_modules/rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private url: string = isDevMode() ? 'http://localhost:5000/api/categories' : 'https://kmgtest.azurewebsites.net/api/categories';

  constructor(private http: HttpClient) { }

  //HttpGet api/categories
  public getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.url}`);
  }

  //HttpGet api/categories/{id}
  public getCategory(id: number): Observable<Category> {
    return this.http.get<Category>(`${this.url}/${id}`);
  }

  //HttpPost api/categories
  public createCategory(category: Category): Observable<Category> {
    return this.http.post<Category>(`${this.url}`, category);
  }

  //HttpPut api/categories/{id}
  public updateCategory(id: number, category: Category): Observable<boolean> {
    return this.http.put<boolean>(`${this.url}/${id}`, category);
  }

  //HttpDelete api/categories/{id}
  public deleteCategory(id: number, deleteRelatedProducts: boolean = false): Observable<boolean> {
    return this.http.delete<boolean>(`${this.url}/${id}?deleteRelatedProducts=${deleteRelatedProducts}`);
  }
}
