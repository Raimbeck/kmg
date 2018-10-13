import { Component, OnInit, OnDestroy } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { ActivatedRoute, Router } from '../../../../node_modules/@angular/router';
import { Product } from '../../interfaces/product';
import { Subscription, Observable } from '../../../../node_modules/rxjs';
import { Category } from '../../interfaces/category';
import { CategoryService } from '../../services/category.service';
import * as _ from 'underscore';
import { FieldValue } from '../../interfaces/field-value';
import { ToastrService } from '../../../../node_modules/ngx-toastr';
import { MatDialog } from '../../../../node_modules/@angular/material/dialog';
import { ConfirmModalComponent } from '../confirm-modal/confirm-modal.component';


@Component({
  selector: 'admin-product-details',
  templateUrl: './admin-product-details.component.html',
  styleUrls: ['./admin-product-details.component.css']
})
export class AdminProductDetailsComponent implements OnInit {
  id: number;
  product: Product;
  isLoading: boolean = true;
  categories: Category[];

  //Subscriptions
  productSub: Subscription;
  editProductSub: Subscription;
  categorySub: Subscription;
  dialogSub: Subscription;
  
  constructor(
    private service: ProductService, private route: ActivatedRoute, 
    private categoryService: CategoryService, private router: Router,
    private toastrService: ToastrService, private dialog: MatDialog
  ) {}

  ngOnInit() {
    this.id = parseInt(this.route.snapshot.paramMap.get('id'));

    this.categorySub = this.categoryService.getCategories().subscribe(response => this.categories = response);

    if(this.id) {
      this.isLoading = true;

      this.productSub = this.service.getProduct(this.id).subscribe(response => {
        this.product = response;
        this.isLoading = false;
      });
    }
    else { 
      this.product = new Product();
      this.isLoading = false;
    }
  }

  submit() {
    this.editProductSub = this.id
      ? this.service.updateProduct(this.id, this.product).subscribe(response => this.redirect(response))
      : this.service.createProduct(this.product).subscribe(response => this.redirect(response));
  }

  categoryChange() {
    let category: Category = _.find(this.categories, (item: Category) => this.product.categoryId == item.id);
    if(!category) 
      return;

    category.additionalFields.forEach(af => {
      if(!af.fieldValue)
        af.fieldValue = new FieldValue();
    });

    this.product.category = category;
  }

  redirect(result) {
    if(result)
      this.toastrService.success("Success.");
    else
      this.toastrService.info("No changes");

    this.router.navigate(['/admin-product']);
  }

  deleteProduct() {
    const dialogRef = this.dialog.open(ConfirmModalComponent, {
      width: '400px',
      data: {
        title: 'Delete',
        message: 'Are you sure you want to delete this product?'
      }
    });

    this.dialogSub = dialogRef.afterClosed().subscribe(result => {
      if(result)
        this.editProductSub = this.service.deleteProduct(this.product.id)
          .subscribe(response => this.redirect(response));
    });
  }

  ngOnDestroy() {
    if(this.productSub) this.productSub.unsubscribe();
    if(this.editProductSub) this.editProductSub.unsubscribe();
    if(this.categorySub) this.categorySub.unsubscribe();
    if(this.dialogSub) this.dialogSub.unsubscribe();
  }

}
