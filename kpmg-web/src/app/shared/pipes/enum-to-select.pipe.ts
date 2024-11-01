import { Pipe, PipeTransform } from '@angular/core';

export interface EnumSelectOption {
  value: number;
  description: string;
}

@Pipe({
  name: 'enumToSelect'
})
export class EnumToSelectPipe implements PipeTransform {
  transform(enumObj: any, labelMapping: Record<number, string>): EnumSelectOption[] {
    return Object.keys(enumObj)
      .filter(key => isNaN(Number(key)))
      .map(key => ({
        value: enumObj[key as keyof typeof enumObj],
        description: labelMapping[enumObj[key as keyof typeof enumObj]]
      }));
  }
}
