import { ProductService } from './../../services/product.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription, Observable } from '../../../../node_modules/rxjs';
import { Product } from '../../interfaces/product';
import { Category } from '../../interfaces/category';
import { CategoryService } from '../../services/category.service';
import { ActivatedRoute } from '../../../../node_modules/@angular/router';
import { switchMap } from "rxjs/operators";

@Component({
  selector: 'products',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit, OnDestroy {
  products: Product[] = [];
  filteredProducts: Product[] = [];
  categories$: Observable<Category[]>
  routeCategory: string;

  //Subscriptions
  productSub: Subscription;
  routeSub: Subscription;

  constructor(private service: ProductService, private categoryService: CategoryService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.routeSub = this.service.getProducts()
      .pipe(switchMap(response => {
          this.products = response;
          return this.route.queryParamMap;
        }))
        .subscribe(route => {
          this.routeCategory = route.get('category');
    
          this.filteredProducts = this.routeCategory
            ? this.products.filter(p => p.category && p.category.name == this.routeCategory)
            : this.products;
        });

    this.categories$ = this.categoryService.getCategories();
  }

  ngOnDestroy() {
    if(this.productSub) this.productSub.unsubscribe();
    if(this.routeSub) this.routeSub.unsubscribe();
  }

}
