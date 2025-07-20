import { useState, type CSSProperties } from "react";
import Button from "../shared/ui/button";
import Edit from "../shared/ui/edit";
import './form_guest.css';
import DeleteGuest from "../features/delete_guest";
import ChangeGuest from "../features/change_guest";
interface GuestFormProps
{
	gId: number;
	gName: string;
	gSurname: string;
	gPhone: string;
	gEmail: string;
}
const GuestForm = ({gId, gName, gSurname, gPhone, gEmail}: GuestFormProps)=>
{
	const [id,setId] = useState<string>(gId.toString());
	const [name, setName]=useState<string>(gName);
	const [surname, setSurname]=useState<string>(gSurname);
	const [phone, setPhone]=useState<string>(gPhone);
	const [email, setEmail] = useState<string>(gEmail);
	const [del, setDel] = useState<boolean>(false);
	const [change, setChange] = useState<boolean>(false);
	const on_delete_click = ()=>{setDel(!del);}
	const on_change_click = ()=>{setChange(!change);}
	if (del) return (<DeleteGuest dId={gId} />);
	if (change)
	{
		return (<ChangeGuest cId={id} cName={name} cSurname={surname} cPhone={phone} cEmail={email} />);
	}
	return (
		<>
			<div className="GuestForm" style={{
				position:'relative',top:100, height:128} as CSSProperties
				}>
				<Edit
					left={20}
					top={8}
					label={'id'}
					id={'idg'}
					style={0}
					value={id}
					onChange={setId}
				/>
				<Edit
					left={300}
					top={8}
					label={'Name'}
					id={'idn'}
					style={0}
					value={name}
					onChange={setName}
				/>
				<Edit
					left={580}
					top={8}
					label={'Surname'}
					id={'idsn'}
					style={0}
					value={surname}
					onChange={setSurname}
				/>
				<Edit
					left={860}
					top={8}
					label={'Phone'}
					id={'idp'}
					style={0}
					value={phone}
					onChange={setPhone}
				/>
				<Edit
					left={1140}
					top={8}
					label={'Email'}
					id={'ide'}
					style={0}
					value={email}
					onChange={setEmail}
				/>
				<Button
					label={'delete'}
					left={1500}
					top={50}
					action={on_delete_click}
					style={0}
				/>
				<Button
					label={'change'}
					left={1620}
					top={50}
					action={on_change_click}
					style={0}
				/>
			</div>
		</>
	);
}
export default GuestForm;
