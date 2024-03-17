import { OrderItem } from './OrderItem';

export interface ICity {
  cityId: number | undefined;
  name: string | undefined;
}

export class City implements ICity {
  _cityId: number | undefined;
  _name: string | undefined;

  get cityId() {
    return this._cityId;
  }

  get name() {
    return this._name;
  }
}
