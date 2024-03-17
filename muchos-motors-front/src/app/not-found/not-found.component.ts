import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrl: './not-found.component.css',
})
export class NotFoundComponent {
  @Input() visible: boolean = false;
  @Input() notFoundMessage: string = 'Ništa nije pronađeno';
  @Input() resetlLinkText: string = 'Resetujte pretragu';
  @Input() resetLinkRoute: string = '/';
}
