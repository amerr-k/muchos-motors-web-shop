import { CarBrand } from './CarBrand';

class GenericCarModel {
  genericCarModelId!: number;
  generationName!: string;
  modelName!: string;
  carBrandId!: number;
  carBrand!: CarBrand;
  productionStartYear?: number;
  productionEndYear?: number;
  isValid!: boolean;
}

export default GenericCarModel;
