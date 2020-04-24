import { Component, OnInit , Inject} from '@angular/core';
import {Router} from "@angular/router";
import {Loja} from "../../model/loja.model";
import {ApiService} from "../../service/api.service";

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  lojas: Loja[];

  constructor(private router: Router, private apiService: ApiService) { }

  ngOnInit() {
    this.apiService.getLojas()
      .subscribe( data => {
        this.lojas = data;
      });
  }

  deleteLoja(loja: Loja): void {
    this.apiService.deleteLoja(loja.idLoja)
      .subscribe( data => {
        if(data !== undefined){
          alert('Loja apagada');
          this.lojas = this.lojas.filter(u => u !== loja);
        }else{
          alert('Não apagou :(');
        }
      },
      error => {
        alert(error);
      })
  };

  editLoja(loja: Loja): void {
    window.localStorage.removeItem("idLojaEdit");
    window.localStorage.setItem("idLojaEdit", loja.idLoja.toString());
    this.router.navigate(['loja/edit/' + loja.idLoja]);
  };

  addLoja(): void {
    this.router.navigate(['loja/add']);
  };

}
