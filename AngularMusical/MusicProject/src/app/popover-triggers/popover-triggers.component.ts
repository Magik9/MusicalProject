import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-popover-triggers',
  templateUrl: './popover-triggers.component.html',
  styleUrls: ['./popover-triggers.component.css']
})
export class PopoverTriggersComponent {
  @Input() data: any;
}
