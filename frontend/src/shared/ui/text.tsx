import type { CSSProperties, JSX } from "react";
import './text.css';
interface TextProps
{
  label: string;
  left: number;
  top: number;
  style: number;
}
const Text = ({label , left , top , style }:TextProps) : JSX.Element =>
{
  let class_style : string = "";
  switch(style)
  {
    case 0:
      class_style = 'text_style0';
      break;
    case 1:
      class_style = 'text_style1';
      break;
    case 2:
      class_style = 'text_style2';
      break;
    case 3:
      class_style = 'text_style3';
      break;
  }
  return <div className={class_style} style={
    {
      position: "absolute",
      left: left,
      top: top
    }as CSSProperties
    }>
    {label}
    </div>;
}
export default Text;
