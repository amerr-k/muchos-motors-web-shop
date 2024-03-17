export class CarPart {
  carPartId!: number;
  code!: string;
  name!: string;
  sellingPrice!: number;
  purchasePrice!: number;
  warehouseCount!: number;
  details?: string;
  carPartCategory!: string;
  base64Image?: string | undefined;
}
