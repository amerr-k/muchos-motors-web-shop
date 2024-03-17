import { CarPart } from './CarPart';
import { Customer } from './Customer';
import { OrderItem } from './OrderItem';

export class InventoryCarPartLog {
  inventoryCarPartLogId?: number | undefined;
  carPartId?: number | undefined;
  carPart?: CarPart | undefined;
  numberOfParts?: number | undefined;
  isValid?: boolean | undefined;
}
