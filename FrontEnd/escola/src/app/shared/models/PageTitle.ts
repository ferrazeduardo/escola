export interface PageTitle {
  title: String;
  description?: String;
  button?: PageTitleButton;
}

export interface PageTitleButton{
    title: string;
    icon: any;
    routerLink?: string;
    backButton?:boolean,
    callBack?: any,
    showed?:boolean
}
