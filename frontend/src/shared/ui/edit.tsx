import {type JSX, type CSSProperties }from 'react';
import './edit.css';
interface EditProps
{
  left: number;
  top: number;
  label: string;
  id : string;
  style : number;
  value : string;
  onChange: (value: string)=>void;
}
const edit = ({left, top, label,id, style, value, onChange}: EditProps): JSX.Element =>
{
  let class_style_label : string = '';
  let class_style_input : string = '';
  let class_style_container : string = '';
  switch(style)
  {
    case 0:
      class_style_label = 'edit_style_label0';
      class_style_input = 'edit_style_input0';
      class_style_container = 'edit_style_container0';
      break;
  }
  return (
    <div className={class_style_container} style={{position:'absolute', left:left, top:top}as CSSProperties}>
      <label htmlFor={id} className={class_style_label}></label>
      <input type='text' id={id} className={class_style_input} value={value} onChange={(e) => onChange(e.target.value)} placeholder={label}/>
        </div>
  );
}
export default edit;
