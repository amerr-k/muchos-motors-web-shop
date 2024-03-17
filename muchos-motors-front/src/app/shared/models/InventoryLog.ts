import { Customer } from './Customer';
import { InventoryCarPartLog } from './InventoryCarPartLog';
import { OrderItem } from './OrderItem';

export class InventoryLog {
  inventoryLogId: number | undefined;
  createdBy: string | undefined;
  createdDate: Date | undefined;
  isValid: boolean | undefined;
  inventoryCarPartLogs: InventoryCarPartLog[] | undefined;
}
