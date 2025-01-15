import { environment } from "../../../environments/environment";

export interface IssueShortInfo {
    id: number;
    title: string;
    description: string;
    year: number;
    number: number;
    publishedAt: Date;
    coverImageUrl: string;
}

export function convertToIssueShortInfo(item: any): IssueShortInfo {
    console.log(item)
    return {
        id: item.id,
        title: item.title,
        description: item.description,
        year: new Date(item.publishedAt).getFullYear(),
        number: item.number,
        publishedAt: new Date(item.publishedAt),
        coverImageUrl: `${environment.staticFilesUrl}/${item.coverImageUrl}`
    }
}