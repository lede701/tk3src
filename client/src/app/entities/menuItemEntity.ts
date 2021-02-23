export class MenuItemEntity {
  public name: string = '';
  public route: string = '';
  public alias: string = '';
  public activeClass: string = 'active';

  public children: MenuItemEntity[] = [];
  public parent: any;

  constructor(name: string, route: string, alias: string, activeClass?: string, parent?: MenuItemEntity) {
    this.name = name;
    this.route = route;
    this.alias = alias;
    if (activeClass !== undefined) {
      this.activeClass = activeClass;
    }
    if (parent !== undefined) {
      this.parent = parent;
    }
  }

  AddChild(child: MenuItemEntity) {
    child.parent = this;
    this.children.push(child);
    return child;
  }

}
