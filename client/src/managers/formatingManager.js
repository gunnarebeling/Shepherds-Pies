export const formatTime = (dateTime) => {
        
    const date = new Date(dateTime.slice(0,-1));
  
    let hours = date.getHours();
    const minutes = date.getMinutes().toString().padStart(2, "0");
    const ampm = hours >= 12 ? "PM" : "AM";
  
   
    hours = hours % 12 || 12; 
  
    return `${hours}:${minutes} ${ampm}`;
  };
  export const formatPrice = (price) => {
    return price.toLocaleString('en-US', {
        style: 'currency',
        currency: 'USD',
        minimumFractionDigits: 2,
        maximumFractionDigits: 2
      });
  }