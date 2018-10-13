import { CategoryService } from './../../services/category.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { MatTableDataSource } from '../../../../node_modules/@angular/material/table';
import { Category } from '../../interfaces/category';
import { Subscription } from '../../../../node_modules/rxjs';

@Component({
  selector: 'app-admin-category',
  templateUrl: './admin-category.component.html',
  styleUrls: ['./admin-category.component.css']
})
export class AdminCategoryComponent implements OnInit, OnDestroy {

  displayedColumns: string[] = ['name', 'fields', 'productsCount'];
  dataSource: MatTableDataSource<Category>;

  categorySub: Subscription;

  constructor(private service: CategoryService) { }

  ngOnInit() {
    this.categorySub = this.service.getCategories().subscribe(response => {
      this.dataSource = new MatTableDataSource(response);
      console.log(response)
    });
  }

  filter(input: HTMLInputElement) {
    this.dataSource.filter = input.value.trim().toLowerCase();
  }

  ngOnDestroy() {
    if(this.categorySub) this.categorySub.unsubscribe();
  }

}
