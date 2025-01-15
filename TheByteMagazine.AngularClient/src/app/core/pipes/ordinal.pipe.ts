import { Pipe, PipeTransform } from "@angular/core";


@Pipe({
    name: 'ordinal',
    standalone: true
})
export class OrdinalPipe implements PipeTransform {
    transform(value: number | undefined): string {
        if (!value) return "N/A";

        let suffix = 'th';
        if (value % 10 === 1 && value % 100 !== 11) {
            suffix = 'st';
        } else if (value % 10 === 2 && value % 100 !== 12) {
            suffix = 'nd';
        } else if (value % 10 === 3 && value % 100 !== 13) {
            suffix = 'rd';
        }
        return value + suffix;
    }

}