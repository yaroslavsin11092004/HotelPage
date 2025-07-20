function scroll_to_form_bookings() : undefined
{
	const elem =  document.getElementById('fb');
	if (elem) elem.scrollIntoView({behavior: 'smooth', block: 'start'});
}
export default scroll_to_form_bookings;
