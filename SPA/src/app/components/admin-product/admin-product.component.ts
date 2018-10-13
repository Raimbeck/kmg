import { Product } from './../../interfaces/product';
import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '../../../../node_modules/@angular/material/table';
import { Subscription } from '../../../../node_modules/rxjs';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'admin-product',
  templateUrl: './admin-product.component.html',
  styleUrls: ['./admin-product.component.css']
})
export class AdminProductComponent implements OnInit {

  displayedColumns: string[] = ['name', 'category', 'price'];
  dataSource: MatTableDataSource<Product>;

  productSub: Subscription;

  constructor(private service: ProductService) { }

  ngOnInit() {
    this.productSub = this.service.getProducts().subscribe((response: Product[]) => {
      response.forEach(r => r['categoryName'] = r.category ? r.category.name : 'None');
      this.dataSource = new MatTableDataSource(response);
    });
  }

  filter(input: HTMLInputElement) {
    this.dataSource.filter = input.value.trim().toLowerCase();
  }

  ngOnDestroy() {
    if(this.productSub) this.productSub.unsubscribe();
  }

}
