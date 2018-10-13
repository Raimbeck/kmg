import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from "@angular/material/table";
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from "@angular/material/button";
import { ToastrModule } from 'ngx-toastr';
import { NgbDropdownModule } from "@ng-bootstrap/ng-bootstrap";

import { AppComponent } from './app.component';
import { AdminCategoryComponent } from './components/admin-category/admin-category.component';
import { AdminProductComponent } from './components/admin-product/admin-product.component';
import { ProductComponent } from './components/product/product.component';
import { CategoryDetailsComponent } from './components/category-details/category-details.component';
import { AdminProductDetailsComponent } from './components/admin-product-details/admin-product-details.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ProductCardComponent } from './components/product-card/product-card.component';
import { SummaryPipe } from './pipes/summary.pipe';
import { ConfirmModalComponent } from './components/confirm-modal/confirm-modal.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';

@NgModule({
  declarations: [
    AppComponent,
    AdminCategoryComponent,
    AdminProductComponent,
    ProductComponent,
    CategoryDetailsComponent,
    AdminProductDetailsComponent,
    NavbarComponent,
    ProductCardComponent,
    SummaryPipe,
    ConfirmModalComponent,
    ProductDetailsComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatDialogModule,
    MatButtonModule,
    NgbDropdownModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'products/:id', component: ProductDetailsComponent },
      { path: 'products', component: ProductComponent },
      { path: 'admin-category/:id', component: CategoryDetailsComponent },
      { path: 'admin-category/new', component: CategoryDetailsComponent },
      { path: 'admin-product/:id', component: AdminProductDetailsComponent },
      { path: 'admin-product/new', component: AdminProductDetailsComponent },
      { path: 'admin-category', component: AdminCategoryComponent },
      { path: 'admin-product', component: AdminProductComponent },
      { path: '**', component: ProductComponent }
    ]),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      timeOut: 3000
    })
  ],
  entryComponents: [ConfirmModalComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
