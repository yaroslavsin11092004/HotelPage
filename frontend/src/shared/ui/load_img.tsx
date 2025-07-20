import type { JSX } from "react";
import './load_img.css';
function load_img(path: string, style : number) : JSX.Element
{
	if (style == 0)
	{
		return (
			<div>
				<img src={path} alt="Домашнее избражение" className="left-aligned-img"/>
				</div>
		);
	}
	else return (
		<div></div>
	);
}
export default load_img;
