import { Category } from './category';

export class Product {
    id: number;
    name: string;
    imageUrl: string;
    description: string;
    price: number;
    category: Category;
    categoryId: number;

    constructor(init?: Partial<Product>)
    {
        this.id = 0;
        this.name = '';
        this.imageUrl = '';
        this.description = '';
        this.price = 0;
        this.categoryId = 0;
        this.category = new Category();
    }
}
