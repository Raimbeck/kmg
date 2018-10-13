import { Field } from "./field";

export class Category {
    id: number;
    name: string;
    additionalFields: Field[];
    productsCount: number;

    constructor(init?: Partial<Category>) {
        this.name = "";
        this.id = 0;
        this.additionalFields = [];
        Object.assign(this, init);
    }
}
