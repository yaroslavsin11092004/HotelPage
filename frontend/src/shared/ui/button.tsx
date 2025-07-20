import {type CSSProperties, type JSX } from "react";
import './button.css';
type Action = ()=>void;
interface ButtonProps
{
  label : string;
  left: number;
  top: number;
  action : Action;
  style: number;
}
const Button = ({label, left, top,action,style} : ButtonProps) : JSX.Element =>
{
  let class_style : string = '';
  switch(style)
  {
    case 0:
      class_style='button_style0';
      break;
    case 1:
      class_style='button_style1';
      break;
    case 2:
      class_style='button_style2';
      break;
  }
  return (
     <button style={{position:'absolute',left:left,top:top}as CSSProperties} 
      className={class_style}
      onClick={action}>
      {label}
    </button>);
}
export default Button;
