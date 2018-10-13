import { Injectable, isDevMode } from '@angular/core';
import { HttpClient } from '../../../node_modules/@angular/common/http';
import { Observable } from '../../../node_modules/rxjs';
import { Product } from '../interfaces/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private url: string = isDevMode() ? 'http://localhost:5000/api/products' : 'https://kmgtest.azurewebsites.net/api/products';

  constructor(private http: HttpClient) { }

  //HttpGet api/products
  public getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.url}`);
  }

  //HttpGet api/products/{id}
  public getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.url}/${id}`);
  }

  //HttpPost api/products
  public createProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(`${this.url}`, product);
  }

  //HttpPut api/products/{id}
  public updateProduct(id: number, product: Product): Observable<boolean> {
    return this.http.put<boolean>(`${this.url}/${id}`, product);
  }

  //HttpDelete api/products/{id}
  public deleteProduct(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.url}/${id}`);
  }
}
