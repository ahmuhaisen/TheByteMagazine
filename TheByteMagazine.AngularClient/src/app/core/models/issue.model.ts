import { IssueShortInfo } from "./issueShortInfo.model";

export interface Issue extends IssueShortInfo {
    numberOfArticles: number;
    directorNote: string;
    flipHtmlUrl: string;
}