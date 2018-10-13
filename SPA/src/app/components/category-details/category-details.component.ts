import { ConfirmModalComponent } from './../confirm-modal/confirm-modal.component';
import { Category } from './../../interfaces/category';
import { CategoryService } from './../../services/category.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from '../../../../node_modules/rxjs';
import { ActivatedRoute, Router } from '../../../../node_modules/@angular/router';
import { Field } from '../../interfaces/field';
import { ToastrService } from '../../../../node_modules/ngx-toastr';
import { MatDialog } from '../../../../node_modules/@angular/material/dialog';

@Component({
  selector: 'app-category-details',
  templateUrl: './category-details.component.html',
  styleUrls: ['./category-details.component.css']
})
export class CategoryDetailsComponent implements OnInit {

  category: Category;
  id: number;
  isLoading: boolean = true;

  //Subscriptions
  categorySub: Subscription;
  editCategorySub: Subscription;
  dialogSub: Subscription;

  constructor(
    private service: CategoryService, private route: ActivatedRoute,
    private toastrService: ToastrService, private router: Router,
    private dialog: MatDialog
  ) { }

  ngOnInit() {
    this.category = new Category();
    this.id = parseInt(this.route.snapshot.paramMap.get('id'));

    if(this.id) {
      this.isLoading = true;
      
      this.categorySub = this.service.getCategory(this.id).subscribe(response => {
        this.category = response;
        this.isLoading = false;
      });
    }

    else this.isLoading = false;
  }

  addField() {
    this.category.additionalFields.push(new Field());
  }

  removeField(index: number) {
    this.category.additionalFields.splice(index, 1);
  }

  submit() {
    this.editCategorySub = this.id 
      ? this.service.updateCategory(this.id, this.category).subscribe(response => this.redirect(response))
      : this.service.createCategory(this.category).subscribe(response => this.redirect(response));
  }

  redirect(result) {
    if(result)
      this.toastrService.success("Success.");
    else
      this.toastrService.info("No changes");

    this.router.navigate(['/admin-category']);
  }

  deleteCategory() {
    const dialogRef = this.dialog.open(ConfirmModalComponent, {
      width: '400px',
      data: {
        title: 'Delete',
        message: 'Are you sure you want to delete this category?'
      }
    });

    this.dialogSub = dialogRef.afterClosed().subscribe(result => {
      if(result)
        this.editCategorySub = this.service.deleteCategory(this.category.id)
          .subscribe(response => this.redirect(response));
    });
  }

  deleteCategoryWithProducts() {
    const dialogRef = this.dialog.open(ConfirmModalComponent, {
      width: '400px',
      data: {
        title: 'Delete',
        message: `Are you sure you want to delete this category and ${this.category.productsCount} products in it?`
      }
    });

    this.dialogSub = dialogRef.afterClosed().subscribe(result => {
      if(result)
        this.editCategorySub = this.service.deleteCategory(this.category.id, result)
          .subscribe(response => this.redirect(response));
    });
  }

  ngOnDestroy() {
    if(this.categorySub) this.categorySub.unsubscribe();
    if(this.editCategorySub) this.editCategorySub.unsubscribe();
    if(this.dialogSub) this.dialogSub.unsubscribe();
  }


}
