import Edit from "../shared/ui/edit";
import Button from "../shared/ui/button";
import { useState, type CSSProperties } from "react";
import './form_add_guest.css';
import CreateGuest from "../features/create_guest";
const FormAddGuest = ()=>
{
	const [name, setName] = useState<string>('');
	const [surname, setSurname] = useState<string>('');
	const [email, setEmail] = useState<string>('');
	const [phone, setPhone] = useState<string>('');
	const [confirm, setConfirm] = useState<boolean>(false);
	const on_click = ()=>{setConfirm(true);}
	if (confirm) return (<CreateGuest
		cName={name}
		cSurname={surname}
		cEmail={email}
		cPhone={phone}
	/>);
	return (
		<>
			<div className="form_add_guest" style={{position:'relative', top:100, height: 400} as CSSProperties}>
				<Edit
					left={20}
					top={8}
					label={'Name'}
					id={'aidn'}
					style={0}
					value={name}
					onChange={setName}
				/>
				<Edit
					left={20}
					top={80}
					label={'Surname'}
					id={'aidsn'}
					style={0}
					value={surname}
					onChange={setSurname}
				/>
				<Edit
					left={20}
					top={152}
					label={'Email'}
					id={'aide'}
					style={0}
					value={email}
					onChange={setEmail}
				/>
				<Edit
					left={20}
					top={224}
					label={'Phone'}
					id={'aidp'}
					style={0}
					value={phone}
					onChange={setPhone}
				/>
				<Button
					label={'confirm'}
					left={170}
					top={340}
					action={on_click}
					style={0}
				/>
			</div>
		</>
	);
}
export default FormAddGuest;
