import { FieldValue } from './field-value';

export class Field {
    id: number;
    fieldValue: FieldValue;
    categoryId: number;
    name: string;

    constructor() {
        this.name = "";
        this.fieldValue = null;
        this.id = 0;
        this.categoryId = 0;
    }

}
