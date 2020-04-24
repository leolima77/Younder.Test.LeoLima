import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from "./login/login.component";
import { AddComponent } from "./loja/add/add.component";
import { ListComponent } from "./loja/list/list.component";
import { EditComponent } from "./loja/edit/edit.component";

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'loja/add', component: AddComponent },
  { path: 'loja/list', component: ListComponent },
  { path: 'loja/edit/:idLoja', component: EditComponent },
  { path : '', component : ListComponent}
];

export const routing = RouterModule.forRoot(routes);
