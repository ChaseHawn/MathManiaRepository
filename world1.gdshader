shader_type spatial;

uniform vec4 color : source_color;
uniform float amount : hint_range(0, 1);
uniform vec4 other_color : source_color = vec4(1.0); // Default values go after the hint.
uniform sampler2D image : source_color;

void vertex() {
	// Sample the color from the texture
    vec4 texColor = texture(image, UV);

    // Convert the sampled color from sRGB to linear space
    vec3 linearColor = pow(texColor.rgb, vec3(2.2));

    // Blend colors based on the amount
    vec4 finalColor = mix(color, other_color, amount);

    // Output the final color with the desired alpha
    COLOR = vec4(finalColor.rgb * linearColor, finalColor.a * texColor.a);
}

//void light() {
	// Called for every pixel for every light affecting the CanvasItem.
	// Uncomment to replace the default light processing function with this one.
//}
